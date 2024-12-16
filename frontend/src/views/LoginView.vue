<template>

    <!-- // "devDependencies": {
  //   "@vitejs/plugin-vue": "^5.2.1",
  //   "vite": "^6.0.1",
  //   "vite-plugin-vue-devtools": "^7.6.5"
  // } -->
  
    <div class="content">
  <div class="decorative-image">
    <img
      class="realistic-blur-background-store-department-store-supermarket-grocery-store-ai-generated-image-1"
      src=""
    />
  </div>
  <div class="content2">
    <div class="content3">
      <div class="content4">
        <div class="headline">
          <div class="bem-vindo">Bem-vindo</div>
          <div class="loga-se-com-sua-conta-para-continuar">
            Loga-se com sua conta para continuar
          </div>
        </div>
        <div class="form">
          <div class="actions">
            <div class="text-input">
              <div class="label-text">Usuario</div>
              <div class="container">
                <div class="text-input-icons">
                  <div class="text-input-text">
                    <div class="placeholder-text">John Doe</div>
                  </div>
                </div>
              </div>
            </div>
            <div class="text-input">
              <div class="label-text">Senha</div>
              <div class="container">
                <div class="text-input-icons">
                  <div class="text-input-text">
                    <div class="placeholder-text">********************</div>
                  </div>
                </div>
              </div>
            </div>
            <div class="esqueceu-a-senha">Esqueceu a senha?</div>
            <div class="bot-o-primario">
              <div class="label">Entrar</div>
            </div>
          </div>
        </div>
      </div>
      <div class="n-o-possui-uma-conta-cadastra-se">
        <span>
          <span class="n-o-possui-uma-conta-cadastra-se-span">
            Não possui uma conta?
          </span>
          <span class="n-o-possui-uma-conta-cadastra-se-span2">
            Cadastra-se
          </span>
        </span>
      </div>
    </div>
  </div>
</div>
</template>

<style lang="css">
.content,
.content * {
  box-sizing: border-box;
}
.content {
  border-radius: 20px;
  display: flex;
  flex-direction: row;
  gap: 0px;
  align-items: flex-start;
  justify-content: flex-start;
  align-self: stretch;
  flex: 1;
  position: relative;
  overflow: hidden;
  height: 100vh;
}
.decorative-image {
  background: #f8fafb;
  align-self: stretch;
  flex: 1;
  position: relative;
  overflow: hidden;
}
.realistic-blur-background-store-department-store-supermarket-grocery-store-ai-generated-image-1 {
  width: 0vh;
  height: 0vh;
  position: absolute;
  left: 0px;
  top: 0px;
  object-fit: cover;
}
.content2 {
  background: linear-gradient(to left, #ffffff, #ffffff);
  padding: 48px 32px 48px 32px;
  display: flex;
  flex-direction: column;
  gap: 32px;
  align-items: center;
  justify-content: center;
  align-self: stretch;
  flex: 1;
  position: relative;
  overflow: hidden;
}
.content3 {
  border-radius: 8px;
  padding: 32px;
  display: flex;
  flex-direction: column;
  gap: 32px;
  align-items: flex-start;
  justify-content: center;
  width: 100%;
  flex: 1;
  max-width: 500px;
  position: relative;
  overflow: hidden;
}
.content4 {
  display: flex;
  flex-direction: column;
  gap: 32px;
  align-items: flex-start;
  justify-content: center;
  align-self: stretch;
  flex-shrink: 0;
  position: relative;
}
.headline {
  display: flex;
  flex-direction: column;
  gap: 12px;
  align-items: flex-start;
  justify-content: center;
  align-self: stretch;
  flex-shrink: 0;
  position: relative;
}
.bem-vindo {
  color: #000000;
  text-align: center;
  font-family: "Quicksand-Bold", sans-serif;
  font-size: 36px;
  font-weight: 700;
  position: relative;
  align-self: stretch;
}
.loga-se-com-sua-conta-para-continuar {
  color: #434343;
  text-align: center;
  font-family: var(--16-regular-font-family, "Mulish-Regular", sans-serif);
  font-size: var(--16-regular-font-size, 16px);
  font-weight: var(--16-regular-font-weight, 400);
  position: relative;
  align-self: stretch;
}
.form {
  background: rgba(255, 255, 255, 0.03);
  display: flex;
  flex-direction: column;
  gap: 24px;
  align-items: flex-start;
  justify-content: flex-start;
  align-self: stretch;
  flex-shrink: 0;
  position: relative;
}
.actions {
  display: flex;
  flex-direction: column;
  gap: var(--spacing-2xl, 20px);
  align-items: flex-start;
  justify-content: flex-start;
  align-self: stretch;
  flex-shrink: 0;
  position: relative;
}
.text-input {
  display: flex;
  flex-direction: column;
  gap: 8px;
  align-items: flex-start;
  justify-content: flex-start;
  align-self: stretch;
  flex-shrink: 0;
  position: relative;
}
.label-text {
  color: #10002e;
  text-align: left;
  font-family: "Quicksand-Bold", sans-serif;
  font-size: 14px;
  line-height: 20px;
  letter-spacing: 0.4px;
  font-weight: 700;
  position: relative;
  align-self: stretch;
}
.container {
  background: #ffffff;
  border-radius: 8px;
  border-style: solid;
  border-color: #d5d4dc;
  border-width: 1px;
  padding: 12px;
  display: flex;
  flex-direction: row;
  gap: 10px;
  align-items: center;
  justify-content: center;
  align-self: stretch;
  flex-shrink: 0;
  position: relative;
}
.text-input-icons {
  display: flex;
  flex-direction: row;
  gap: 12px;
  align-items: center;
  justify-content: flex-start;
  flex: 1;
  position: relative;
}
.text-input-text {
  display: flex;
  flex-direction: row;
  gap: 4px;
  align-items: center;
  justify-content: flex-start;
  flex: 1;
  position: relative;
}
.placeholder-text {
  color: #8b849b;
  text-align: left;
  font-family: "Quicksand-Medium", sans-serif;
  font-size: 16px;
  line-height: 24px;
  letter-spacing: 0.2px;
  font-weight: 500;
  position: relative;
  flex: 1;
}
.esqueceu-a-senha {
  color: #0170ff;
  text-align: right;
  font-family: "Quicksand-Bold", sans-serif;
  font-size: 16px;
  font-weight: 700;
  position: relative;
  align-self: stretch;
}
.bot-o-primario {
  background: #0170ff;
  border-radius: 4px;
  padding: 12px 24px 12px 24px;
  display: flex;
  flex-direction: row;
  gap: 16px;
  align-items: center;
  justify-content: center;
  align-self: stretch;
  flex-shrink: 0;
  position: relative;
  overflow: hidden;
}
.label {
  color: var(--white, #ffffff);
  text-align: center;
  font-family: var(
    --text-base-600-font-family,
    "Quicksand-SemiBold",
    sans-serif
  );
  font-size: var(--text-base-600-font-size, 16px);
  line-height: var(--text-base-600-line-height, 24px);
  font-weight: var(--text-base-600-font-weight, 600);
  position: relative;
  display: flex;
  align-items: center;
  justify-content: center;
}
.n-o-possui-uma-conta-cadastra-se {
  text-align: center;
  font-family: "Quicksand-Bold", sans-serif;
  font-size: 16px;
  font-weight: 700;
  position: relative;
  align-self: stretch;
}
.n-o-possui-uma-conta-cadastra-se-span {
  color: #434343;
  font-family: "Quicksand-Bold", sans-serif;
  font-size: 16px;
  font-weight: 700;
}
.n-o-possui-uma-conta-cadastra-se-span2 {
  color: #0170ff;
  font-family: "Quicksand-Bold", sans-serif;
  font-size: 16px;
  font-weight: 700;
}

@media screen and (max-width: 992px) 
{
    .decorative-image
    {
        visibility: collapse;
    }

    .content2
    {
      width: 100vh;
    }
}


</style>

