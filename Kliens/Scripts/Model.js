let URL = 'https://localhost:7089/api/User';

export let users = [];

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

      users = await response.json();
    } catch (error) {
      throw error;
    }
  }

}



export const model = new Model();
