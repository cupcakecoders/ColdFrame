import React, { Component } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import authService from "../api-authorization/AuthorizeService";

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
            .then(response => {console.log(response)})
                    /*.then(data =>
                        this.setState({
                            plants: data
                }))*/
            .catch(error => {console.log(error)})
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
                    <DropdownItem>Some Action</DropdownItem>
                    <DropdownItem disabled>Action (disabled)</DropdownItem>
                    <DropdownItem divider />
                    <DropdownItem>Foo Action</DropdownItem>
                    <DropdownItem>Bar Action</DropdownItem>
                    <DropdownItem>Quo Action</DropdownItem>
                </DropdownMenu>
            </Dropdown>
        );
    }
}
