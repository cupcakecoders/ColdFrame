import React from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

export default class PlantsDropDown extends React.Component {
    
    constructor(props) {
        super(props);
        this.state = {
            isOpen: false,
        }
        this.toggleDropdown = this.toggleDropdown.bind(this);
    }
    
    toggleDropdown() {
        this.setState({isOpen: !this.state.isOpen})
    }
    
    render () { console.log(this.props.plantsData)
        return (
            <Dropdown isOpen={this.state.isOpen} toggle={this.toggleDropdown} >
                <DropdownToggle caret>
                    Select a plant
                </DropdownToggle>
                <DropdownMenu>
                    {this.props.plantsData.map(plant => <DropdownItem>{plant.plantName}</DropdownItem>)}
{/*
  on select load plant details component pass id as prop to this component. then get plant.description.
*/}
                </DropdownMenu>
            </Dropdown>
        );
    }
}
