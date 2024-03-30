"use strict";

let defaultURL = "https://localhost:7089/api/";

class FetchAPI {
  constructor() {
    this.Students = [
      {
        studentid: 1,
        firstname: "Attila",
        lastname: "Vegh",
        email: "attila@example.com",
        neptuncode: "MYWTLT",
        courses: ["Mobil Prog", "Haladó inf", "Rendszerfejlesztés"],
      },
      {
        studentid: 2,
        firstname: "Kristof",
        lastname: "Varga",
        email: "krostof@example.com",
        neptuncode: "DHKOHH",
        courses: ["Mobil Prog", "Haladó inf", "Rendszerfejlesztés"],
      },
      {
        studentid: 3,
        firstname: "Mate",
        lastname: "Valcz",
        email: "mate@example.com",
        neptuncode: "RYRHJ0",
        courses: ["Mobil Prog", "Haladó inf", "Rendszerfejlesztés"],
      },
    ];
  }

  async postData(slug = "", data = {}) {
    const response = await fetch(defaultURL + slug, {
      method: "GET",
      mode: "cors",
      cache: "no-cache",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      redirect: "follow",
      referrerPolicy: "no-referrer",
      body: JSON.stringify(data),
    });
    if (response.status == 401 || response.status == 403) {
      console.log("error");
    }
    // return response.json();
    console.log(response.json());
  }

  async getData(slug = "") {
    const response = await fetch(defaultURL + slug, {
      method: "GET",
      mode: "cors",
      cache: "no-cache",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      redirect: "follow",
      referrerPolicy: "no-referrer",
    });
    if (response.status == 401 || response.status == 403) {
      console.log("error");
    }
    //const students = response.json();
    //console.log(students);
    return this.Students;
  }

  printJsonContent() {
    const Students = [...this.Students];
    const [loggedInStudent] = Students.filter((student) => {
      return student.email == localStorage.getItem("email");
    });
    document.querySelector("#loggedInStudent").textContent =
      loggedInStudent.firstname + " " + loggedInStudent.lastname;
    let d = document.querySelector(".courses");
    for (const course of loggedInStudent.courses) {
      let c = document.createElement("div");
      c.innerHTML = course;
      c.classList.add("course");
      d.appendChild(c);
    }
  }

  logOut() {
    localStorage.clear();
    window.location.href = "login.html";
  }
}

let fetchAPI = new FetchAPI();
// fetchAPI.getData("Student");
fetchAPI.printJsonContent();
