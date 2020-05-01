import React, { Component } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import authService from "../api-authorization/AuthorizeService";
import {Plant} from "../../api-users-plants/UserPlantConstants";

export default class PlantsDropDown extends React.Component {
    
    constructor(props) {
        super(props);
        this.state = {
            isOpen: false,
            plants: []
        }
        this.toggleDropdown = this.toggleDropdown.bind(this);
    }

    
    componentDidMount() {
        fetch("https://localhost:5001/plants")
            .then(response => response.json())
            //.then(response => {console.log(response)})
            .then(plantsData => {this.setState({plants: plantsData});
            })
            .catch(error => {console.log(error)}
            )
    }
    
    toggleDropdown() {
        this.setState({isOpen: !this.state.isOpen})
    }
    
    render () {
        return (
            <Dropdown isOpen={this.state.isOpen} toggle={this.toggleDropdown}>
                <DropdownToggle caret>
                    Dropdown
                </DropdownToggle>
                <DropdownMenu>
                    <DropdownItem header>Header</DropdownItem>
                    <DropdownItem disabled>Action (disabled)</DropdownItem>
                    <DropdownItem divider />
                    <DropdownItem>Bar Action</DropdownItem>
                    <DropdownItem>Quo Action</DropdownItem>
                </DropdownMenu>
            </Dropdown>
        );
    }
}
