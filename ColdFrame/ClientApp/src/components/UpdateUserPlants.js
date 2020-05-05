import React, {Component} from 'react';
import authService from "./api-authorization/AuthorizeService";

export class UpdateUserPlants extends Component {
    constructor() {
        super();
    }
    
    async componentDidMount() {
        const user = await authService.getUser();
        console.log("user", user)


    }
    
    
    render() {
        //get current plant
        //const plantId =  
        
        return (
            <div><p>Update User Plants</p></div>
        )
    }
}