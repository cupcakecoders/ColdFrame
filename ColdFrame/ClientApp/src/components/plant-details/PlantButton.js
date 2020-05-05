import React, { Component } from 'react';
import { Button } from 'reactstrap';
import {addPlantToUser} from "../../api";

export class AddPlantButton extends Component {
    addPlantToUser = async () => {
        const userId = this.props.userId;
        const plantId = this.props.plantId;
        const errorMessage = 'Something went wrong adding a plant'
        try {
            const addedPlant = await addPlantToUser(plantId, userId);
            if (!addedPlant) {
                alert(errorMessage)
            }
        } catch (error) {
            console.log('Error adding plant', error)
            alert(errorMessage)
        }
    }
    render() {
        return (
            <div>
                <Button onClick={this.addPlantToUser} color="info">Add to My Plants</Button>
            </div>
        );
    }
}


