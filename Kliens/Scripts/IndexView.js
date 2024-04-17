class IndexView {

  addHandlerLogOut(handler) {
    document.querySelector('.btn--logout').addEventListener('click', handler);
  }

  printUsers(data) {
    let students = data;

    // Userek listázása
    let d = document.querySelector('.courses');
    for (const student of students) {
      let studentHTML = `<div class="course">${student.name} (${student.username})</div>`;
      d.insertAdjacentHTML('beforeend', studentHTML);
    }
  }
}

export default new IndexView();
