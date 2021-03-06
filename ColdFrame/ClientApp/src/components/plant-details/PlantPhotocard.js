﻿import React from 'react';
import {
    Card, CardImg, CardText, CardBody,
    CardTitle, Button
} from 'reactstrap';
import CardGroup from "reactstrap/es/CardGroup";

export default class PlantPhotocard extends React.Component {
    
    render() {
        return(
            <CardGroup>
                <Card>
                    <CardImg top width="100%" src={this.props.plants.imageUrl} alt="Card image cap" />
                    <CardBody>
                        <CardTitle>{this.props.plants.plantName}</CardTitle>
                        <CardText>{this.props.plants.description}</CardText>
                        <Button href={`https://localhost:5001/plant/${this.props.plants.id}`}>See more</Button>
                    </CardBody>
                </Card>
            </CardGroup>        
        );
    }
};
