import React, { Component } from 'react';
import { Media, Col, Container, Row } from 'reactstrap';
import authService from "./api-authorization/AuthorizeService";
import {getUserDetails} from "../api";
import Loading from "./Loading";
import Moment from 'react-moment';

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
            <Container>
                <Row>
                    <Col>
                        <h1>Hello gardener! </h1>
                        <h6>Plants you've chosen to grow.</h6>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        {this.state.userDetails.plantUsers.map(plant => (
                            <Media className="mt-1" key={plant.plantId}>
                                <Media left>
                                    <Media object src={`${plant.plant.imageUrl}`} alt="plant image" width={65} />
                                </Media>
                                <Media body>
                                    <Media heading>
                                        {plant.plant.plantName}
                                    </Media>
                                    <p>{plant.plant.description}</p>    
                                    <p><strong>Sow From Date:</strong> <Moment format="MMMM">{plant.plant.sowFrom}</Moment></p>
                                    <p><strong>Sow To Date: </strong><Moment format="MMMM">{plant.plant.sowTo}</Moment></p>
                                    <p><strong>Harvest From Date: </strong><Moment format="MMMM">{plant.plant.harvestFrom}</Moment></p>
                                    <p><strong>Harvest To Date: </strong><Moment format="MMMM">{plant.plant.harvestTo}</Moment></p>
                                </Media>
                            </Media>
                        ))}
                    </Col>
                </Row>
            </Container>
        )
    }
}