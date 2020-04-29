import React from 'react';
import authService from "../components/api-authorization/AuthorizeService.js"

export const User = {
   UserName: 'userName'
};

export const Plant = {
    PlantName: 'plantName',
    Description: 'description',
    SowFrom: 'sowFrom',
    SowTo: 'sowTo',
    HarvestFrom: 'harvestFrom',
    HarvestTo: 'harvestTo',
    ImageUrl: 'imageUrl'
};

export async function populateUserPlantData() {
    const token = await authService.getAccessToken();
    const response = await fetch('https://localhost:5001/users/${id}', {
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
}


