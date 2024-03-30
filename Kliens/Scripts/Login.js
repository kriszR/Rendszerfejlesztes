'use strict';

class Login {
  constructor() {}

  validateUser() {
    let email = document.querySelector("#useremail").value;
    let pw = document.querySelector("#userpw").value;

    if (!email || !pw) {
      alert("Email és jelszó megadása kötelező!");
    } else if (!this.validateEmail(email)) {
      alert("Nem megfelelő email");
    } else {
      localStorage.setItem('email', email);
      window.location.href = "index.html";
    }
  }

  validateEmail(email) {
    const validRegex =
      /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    return email.match(validRegex);
  }
}

let login = new Login();
