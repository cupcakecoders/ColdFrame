import React, { Component } from 'react';
import {AddPlantButton, DropDownResult} from './plant-details/PlantDetail';
import PlantsDropDown from "./plant-details/PlantsDropdown";

export class PlantsPage extends Component {
    render() {
        return (
            <div>
                <PlantsDropDown />
                <DropDownResult />
                <AddPlantButton />
            </div>
        );
    }
}
