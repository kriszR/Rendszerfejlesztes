class FetchAPI {
  constructor() {
    this._checkLogin();
  }

  async deleteData(id) {
    try {
      const response = await fetch(defaultURL + 'Students/' + id, {
        method: 'DELETE',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
        //body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error('Failed to fetch');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  }

  async postData(slug = '', data = {}) {
    try {
      const response = await fetch(defaultURL + slug, {
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error('Failed to fetch');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  }

  createStudentData() {
    try {
      let inputs = document.querySelectorAll('input');
      const data = {
        id: 0,
        username: inputs[0].value,
        name: inputs[1].value,
        password: inputs[2].value,
      };
      this.postData('Students', data);
    } catch (error) {
      console.error(error);
    }
  }



  _checkLogin() {
    if (!localStorage.getItem('username')) {
      console.log('Nincs bejelentkezve');
      window.location.href = 'login.html';
    }
  }
}

