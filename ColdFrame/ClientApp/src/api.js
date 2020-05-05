export async function getUserDetails(id) {
  return fetch(`https://localhost:5001/users/${id}`)
      .then(response => (response.json()))
}

export async function addPlantToUser(plantId, userId) {
  return fetch(`https://localhost:5001/users/${userId}/add-plant/${plantId}`, {
    method: 'PATCH',
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(response => response.ok)
}

export async function getPlantDetails(plantId) {
  return fetch(`https://localhost:5001/plants/${plantId}`)
      .then(response => (response.json()))
}