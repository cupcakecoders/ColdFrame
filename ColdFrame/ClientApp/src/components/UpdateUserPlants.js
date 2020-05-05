import React, {Component} from 'react';
import authService from "./api-authorization/AuthorizeService";

export class UpdateUserPlants extends Component {
    constructor() {
        super();
    }
    
    async componentDidMount() {
        const user = await authService.getUser();
        console.log("user", user)

        fetch(`https://localhost:5001/users${user.sub}`, {
            method: 'PATCH',
            body: JSON.stringify(),
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(json => console.log(json))
    }
    
    
    render() {
        //get current plant
        //const plantId =  
        
        return (
            <div><p>Update User Plants</p></div>
        )
    }
}