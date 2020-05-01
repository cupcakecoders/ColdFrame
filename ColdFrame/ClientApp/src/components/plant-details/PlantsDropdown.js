import React from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

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
            .then(plantsData => {this.setState({plants: plantsData});
            })
            .catch(error => {console.log(error)}
            )
    }
    
    toggleDropdown() {
        this.setState({isOpen: !this.state.isOpen})
    }
    
    render () { console.log(this.state.plants)
        return (
            <Dropdown isOpen={this.state.isOpen} toggle={this.toggleDropdown} >
                <DropdownToggle caret>
                    Dropdown
                </DropdownToggle>
                <DropdownMenu>
                    {this.state.plants.map(plant => <DropdownItem>{plant.plantName}</DropdownItem>)}
                </DropdownMenu>
            </Dropdown>
        );
    }
}
