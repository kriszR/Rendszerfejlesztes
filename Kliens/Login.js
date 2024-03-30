class Login {
  constructor() {}

  validateUser() {
    let email = document.querySelector('#useremail').value;
    let pw = document.querySelector('#userpw').value;

    
    // felhasználó validálás
    // ha sikeres, megyünk az index.html-re
    if (true) {
        console.log("Validated");
      window.location.href = "index.html";
    }
  }
}

let login = new Login();
