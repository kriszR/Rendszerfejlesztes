let URL = 'https://localhost:7089/api/User';

export const state = {
  users: [],
  courses: [],
  loggedInUser: '',
};

class Model {
  async getUsers(slug = '') {
    try {
      const response = await fetch(URL + slug, {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
      });

      if (!response.ok) {
        throw new Error('Nem lehet lekérdezni a hallgatókat');
      }

      state.users = await response.json();
    } catch (error) {
      throw error;
    }
  }

  async getUserCourses(slug = '') {
    const response = await fetch(URL + slug, {
      method: 'GET',
      mode: 'cors',
      cache: 'no-cache',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
      },
      redirect: 'follow',
      referrerPolicy: 'no-referrer',
    });

    if (!response.ok) {
      throw new Error('Nem lehet lekérdezni a kurzusokat');
    }

    state.courses = await response.json();
  }
  catch(error) {
    throw error;
  }

  findUser(username, pw) {
    if (!username && !pw) {
      username = JSON.parse(localStorage.getItem('user')).username;
      pw = JSON.parse(localStorage.getItem('user')).pw;
    }
    const user = state.users.find(
      user => user.username === username && user.password === pw
    );
    state.loggedInUser = user;
  }
}

export const model = new Model();
