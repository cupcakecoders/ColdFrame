import authService from "./components/api-authorization/AuthorizeService";

export async function getUserDetails(id) {
  const token = await authService.getAccessToken();
  return fetch(`https://localhost:5001/users/${id}`, {
    headers: !token ? {} : {'Authorization': `Bearer ${token}`}
  }).then(response => (response.json()))
}

export async function addPlantToUser(plantId, userId) {
  const token = await authService.getAccessToken();
  return fetch(`https://localhost:5001/users/${userId}/add-plant/${plantId}`, {
    method: 'PATCH',
    headers: !token ? {} : {'Authorization': `Bearer ${token}`}
  }).then(response => response.ok)
}

export async function getPlantDetails(plantId) {
  const token = await authService.getAccessToken();
  return fetch(`https://localhost:5001/plants/${plantId}`, {
    headers: !token ? {} : {'Authorization': `Bearer ${token}`}
  })
      .then(response => (response.json()))
}

