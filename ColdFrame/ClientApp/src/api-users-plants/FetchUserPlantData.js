import React, { Component } from 'react';
import {User, Plant} from './UserPlantConstants'
import authService from "../components/api-authorization/AuthorizeService.js"

export class FetchUserPlantData extends Component {

    constructor(props) {
        super(props);
        this.state = { userplants: [], loading: true };
    }
    
    componentDidMount() {
        this.fetchUserPlants();
    }

    //render = () => { <
        /*let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchUserPlantData.renderForecastsTable(this.state.userplants);
            
        return (
            <div>
                <h1 id="userData">Hello User</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );*/
    //}

    async populateUserPlantData() {
        const token = await authService.getAccessToken();
        const response = await fetch('https://localhost:5001/users/${id}', {
            headers: !token ? {} : {'Authorization': `Bearer ${token}`}
        });
        const data = await response.json();
        this.setState({ userplants: data, loading: false });
        
    }
    
}


