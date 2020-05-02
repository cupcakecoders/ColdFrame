import React, { Component } from 'react';
import {PlantCard} from './plant-details/PlantDetail';
import PlantsDropDown from "./plant-details/PlantsDropdown";

export class PlantsPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            plants: []
        }
    }

    componentDidMount() {
        fetch("https://localhost:5001/plants")
            .then(response => response.json())
            .then(plantsData => {this.setState({plants: plantsData});
            })
            .catch(error => {console.log(error)}
            )
    }
    
    render() {
        return (
            <div>
                <PlantsDropDown 
                    plantsData={this.state.plants}
                />
                <PlantCard 
                    plantsData={this.state.plants}
                />
            </div>
        );
    }
}
