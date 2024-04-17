class LoginView {

  addHandlerLogIn(handler) {
    document.querySelector('.btn--login').addEventListener('click', function(e) {
      e.preventDefault();
      const username = document.querySelector('#username').value;
      const pw = document.querySelector('#userpw').value;
      handler(username, pw);
    })
  }

}

export default new LoginView();
