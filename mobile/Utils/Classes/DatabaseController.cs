using FluxoDeCaixa.Data.Repositories;

namespace FluxoDeCaixa.MAUI.Utils.Classes;

public class DatabaseController
{

    private CategoryRepository _CategoryRepository = null;
    public CategoryRepository CategoryRepository
    {
        get
        {
            if (_CategoryRepository is null)
                _CategoryRepository = RepositoryProvider.Category;

            return _CategoryRepository;
        }
    }
    
    private TransactionRepository _TransactionRepository = null;
    public TransactionRepository TransactionRepository
    {
        get
        {
            if (_TransactionRepository is null)
                _TransactionRepository = RepositoryProvider.Transaction;

            return _TransactionRepository;
        }
    }



}
