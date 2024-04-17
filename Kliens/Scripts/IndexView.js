class IndexView {

  addHandlerLogOut(handler) {
    document.querySelector('.btn--logout').addEventListener('click', handler);
  }

  printCourses(courses) {
    // Kurzusok listázása
    let d = document.querySelector('.courses');
    for (const course of courses) {
      let studentHTML = `<div class="course">Kód: ${course.code}<br> ${course.name} <br> ${course.credit} kredit</div>`;
      d.insertAdjacentHTML('beforeend', studentHTML);
    }

  }

  showLoggedInUser(user) {
    document.querySelector('#loggedInUser').textContent = `${user.name} (${user.username})`;
  }
}

export default new IndexView();
