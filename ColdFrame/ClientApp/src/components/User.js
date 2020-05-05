import React, { Component } from 'react';
import { Card, CardBody, Button, CardTitle, CardSubtitle, CardText, CardImg, Col, Container, Row } from 'reactstrap';
import authService from "./api-authorization/AuthorizeService";
import {UpdateUserPlants} from "./UpdateUserPlants";

export class Users extends Component {
    constructor(props) {
        super(props);
        this.state = {
            users: [],
            loading: true,
            error: false
        }
    }
    
    async componentDidMount() {
        const user = await authService.getUser();
        console.log("user", user)

        fetch(`https://localhost:5001/users/${user.sub}`)
            .then(response => (response.json()))
            .then(userData => {this.setState({users:userData, loading: false});
            })
            .catch(error => {
                console.log(error);
                this.setState({loading: false, error: error});
            })
    }
    
    render (){
        console.log(this.state.users)
        console.log('plantusersprops', this.props.users);
        console.log('auth', authService);
        if (this.state.loading) {
            return <p>Loading...</p>
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
                            {this.state.users.plantUsers.map(plant => (
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
                        <Button href={"https://localhost:5001/plants-page"} color="info">Add more plants</Button>{' '}
                    </Col>
                </Row>
            </Container>
        )
    }
}