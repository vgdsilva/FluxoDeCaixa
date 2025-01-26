using DevExpress.Maui.Editors;
using FluxoDeCaixa.MAUI.Componentes;
using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Utils.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Utils.Validators
{
    public class FormValidators
    {
        private static bool isValidForm;

        public static bool ValidateForm(Page page, string dataFormGridName)
        {
            try
            {
                if (dataFormGridName == null)
                    return false;

                DataFormGrid gridDataForm = page.FindByName<DataFormGrid>(dataFormGridName);

                _ = gridDataForm ?? throw new NullReferenceException(string.Format("{0} não foi encontrado.", dataFormGridName));

                isValidForm = true;
                var source = GetBaseModelValue(page.BindingContext);
                source.ValidateForm();
                ValidateInDataFormGrid(source, gridDataForm);
            }
            catch (Exception ex)
            {
                SnackBar.ShowError(ex.Message);
            }

            return false;
        }


        private static BaseModels GetBaseModelValue(object bindingContext)
        {
            Type myType = bindingContext.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(bindingContext, null);
                if (propValue is BaseModels)
                {
                    return (BaseModels)propValue;
                }
            }
            return null;
        }

        private static bool ValidateInDataFormGrid(BaseModels source, dynamic grid)
        {
            foreach (View itemChildren in grid.Children)
            {
                if (!itemChildren.IsVisible)
                    continue;

                if (IsValidateInLayoutChildrenTypes(itemChildren))
                    ValidateInDataFormGrid(source, itemChildren);

                if ((itemChildren is EditBase) || (itemChildren is TextEdit))
                {
                    dynamic itemEditBase = itemChildren;

                    if (itemEditBase.PropertyName == null)
                        return false;

                    //validando apenas campos Visiveis
                    if (!itemEditBase.IsVisible) continue;

                    IEnumerable<ValidationResult> listErroValidationResult = source.GetErrors(itemEditBase.PropertyName);
                    ValidationResult erroValidationResult = listErroValidationResult.FirstOrDefault();

                    if (((object)itemEditBase).HasProperty("IsEnabled"))
                        if (erroValidationResult != null)
                        {

                            itemEditBase.HasError = true;
                            itemEditBase.ErrorText = erroValidationResult.ErrorMessage;
                            isValidForm = false;
                            continue;
                        }
                    if (((object)itemEditBase).HasProperty("IsRequired"))
                        if ((bool)((object)itemEditBase).GetPropertyValue("IsRequired") && Valid(source, itemEditBase.PropertyName))
                        {
                            itemEditBase.HasError = true;
                            itemEditBase.ErrorText = "Campo é obrigatório";
                            isValidForm = false;
                            continue;
                        }
                    if (((object)itemEditBase).HasProperty("NeedBiggerThanZero"))
                        if ((bool)((object)itemEditBase).GetPropertyValue("NeedBiggerThanZero"))
                        {
                            var valor = source.GetPropertyValue(((string)itemEditBase.PropertyName), true);

                            if (valor is string && ((string)valor).IsNullOrEmpty() || valor is decimal)
                            {
                                if (Convert.ToDecimal(valor) <= 0)
                                {
                                    itemEditBase.HasError = true;
                                    //itemEditBase.ErrorText = TZ.MSG_VALOR_DEVE_SER_MAIOR_QUE_ZERO().ApenasPrimeiraLetraMaiuscula();
                                    isValidForm = false;
                                    continue;
                                }
                            }
                        }
                    itemEditBase.HasError = false;
                }

            }

            return isValidForm;
        }

        private static bool IsValidateInLayoutChildrenTypes(View view)
        {
            if (view is Grid ||
                view is StackLayout ||
                view is VerticalStackLayout ||
                view is HorizontalStackLayout ||
                view is ScrollView ||
                view is FlexLayout)
                return true;

            return false;
        }

        private static bool Valid(BaseModels source, string prop)
        {
            var value = source.GetPropertyValue(prop, true);
            if (value == null) return true;
            if (value is string)
                return ((string)value).IsNullOrEmpty();
            if (value is long && string.Equals(prop.Substring(0, 2), "ID", StringComparison.InvariantCultureIgnoreCase))
                return (long)value == -1;

            return false;
        }
    }
}
