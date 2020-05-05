import React, { Component } from 'react';
import { Card, CardBody, Button, CardTitle, CardSubtitle, CardText, CardImg, Col, Container, Row } from 'reactstrap';
import authService from "./api-authorization/AuthorizeService";
import {getUserDetails} from "../api";
import Loading from "./Loading";

export default class MyPlants extends Component {
    state = {
        userDetails: null,
        loading: true,
        error: false
    }
    
    async componentDidMount() {
        const user = await authService.getUser();
        try {
            const userDetails = await getUserDetails(user.sub)
            this.setState({userDetails, loading: false});
        } catch (error) {
            this.setState({loading: false, error});
        }
    }
    
    render (){
        if (this.state.loading) {
            return <Loading />
        }
        if (this.state.error) {
            return <p> There was an error getting user - please try later </p>
        }

        
        return (
            <Container fluid={true}>
                <Row>
                    <Col>
                        <h1>Hello gardener! </h1><br></br>
                        <h2>Plants you've chosen to grow.</h2>
                    </Col>
                </Row>
                <Row>
                    <Col fluid={true} sm={{ size: 6, order: 2, offset: 1 }}>
                    <Card>
                            {this.state.userDetails.plantUsers.map(plant => (
                            <React.Fragment key={plant.plantId}>
                                <CardImg top width="100%" src={`${plant.plant.imageUrl}`}/>
                                <CardBody>
                                <CardTitle>{plant.plant.plantName}</CardTitle>
                                <CardText>{plant.plant.description}</CardText>
                                </CardBody>
                            </React.Fragment>
                            ))}
                    </Card>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <Button href={"https://localhost:5001/find-plants"} color="info">Add more plants</Button>{' '}
                    </Col>
                </Row>
            </Container>
        )
    }
}