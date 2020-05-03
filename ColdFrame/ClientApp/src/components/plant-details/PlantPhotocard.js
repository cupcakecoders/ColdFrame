import React from 'react';
import {
    Card, CardImg, CardText, CardBody,
    CardTitle, CardSubtitle, Button
} from 'reactstrap';
import CardLink from "reactstrap/es/CardLink";

export default class PlantPhotocard extends React.Component {
    constructor(props) {
        super(props);
    }

    
    
    render() {
        //for each item in plantsData create a photocard and put in [i] of img, title,
        //interpolate link with /{id}
        
        
        return(
            <div>
                <Card>
                    <CardBody>
                        <CardTitle>{this.props.plants.plantName}</CardTitle>
                    </CardBody>
                    <img width="100%" src="" alt="Card image cap" />
                    <CardBody>
                        <CardText>Some quick example text to build on the card title and make up the bulk of the card's content.</CardText>
                        <CardLink href="#">Card Link</CardLink>
                    </CardBody>
                </Card>
            </div>        
        );
    }
};
