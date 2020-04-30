import React, { Component } from 'react';
import { Button } from 'reactstrap';
import PlantsDropDown from "./plants-dropdown/plants-dropdown";


export class PlantDetails extends Component {
    render() {
        const plant = this.props.plant;
        return (
            <div>
                <h1>{plant}</h1>
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

export class Plants extends Component {
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

const PLANTS = [
    {
        "id": 1,
        "plantName": "Tomato",
        "description": "The tomato is the fruit of the tomato plant, a member of the Nightshade family (Solanaceae). The fruit grows on a sprawling vine that often needs to be supported by a cane to keep it upright.",
        "vegetable": true,
        "fruit": false,
        "sowFrom": "2020-04-20T14:32:54",
        "sowTo": "2020-06-30T14:33:59",
        "harvestFrom": "2020-04-20T14:34:03",
        "harvestTo": "2020-04-20T14:32:08",
        "imageUrl": "https://s3.amazonaws.com/openfarm-project/production/media/pictures/attachments/5dc3618ef2c1020004f936e4.jpg?1573085580"
    },
    {
        "id": 2,
        "plantName": "Broccoli",
        "description": "Broccoli has large flower heads known as crowns that are green to blue-green in color, grouped tightly together atop a thick stem, and surrounded by leaves.",
        "vegetable": true,
        "fruit": false,
        "sowFrom": "2020-01-01T15:47:00",
        "sowTo": "2020-02-01T15:47:16",
        "harvestFrom": "2020-05-01T15:47:33",
        "harvestTo": "2020-06-01T15:47:46",
        "imageUrl": "https://s3.amazonaws.com/openfarm-project/production/media/pictures/attachments/54b4b5ea61306500020b0000.jpg?1421129190"
    }
    ];