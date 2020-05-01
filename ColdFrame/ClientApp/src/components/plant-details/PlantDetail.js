import React, { Component } from 'react';
import { Button } from 'reactstrap';

export class PlantDetails extends Component {
    render() {
        //const plant = this.props.plants;
        const plantName = "tomato";
        //const plantDescription = plant.description;
        return (
            <div>
                <h2>{plantName}</h2>
            </div>
        );
    }
}

export class DropDownResult extends Component {
    render() {
        return (
            <div>
                <PlantDetails/>
            </div>
        );
    }
}

export class AddPlantButton extends Component {
    render() {
        return (
            <div>
                <Button color="info">Add to My Plants </Button>{' '}
            </div>
        );
    }
}
