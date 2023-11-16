import React from 'react';
import Navbar from 'react-bootstrap/Navbar';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Offcanvas from 'react-bootstrap/Offcanvas';
import Button from 'react-bootstrap/Button';
import Login from './Login/Login';
// import Home from './Home';
// import Gallery from './Gallery';

export const NavMenu =() => {
  return (
    <>
      {[ 'xxl'].map((expand) => (
        <Navbar key={expand} expand={expand} className="bg-body-tertiary mb-3">
          <Container fluid>
          <Form className="d-flex">
                  <Form.Control
                    type="search"
                    placeholder="Search"
                    className="me-2"
                    aria-label="Search"
                  />
                  <Button variant="outline-success">Search</Button>
                </Form>
            <Navbar.Brand href="#">Navbar Offcanvas</Navbar.Brand>
            <Navbar.Toggle aria-controls={`offcanvasNavbar-expand-${expand}`} />
            <Navbar.Offcanvas
              id={`offcanvasNavbar-expand-${expand}`}
              aria-labelledby={`offcanvasNavbarLabel-expand-${expand}`}
              placement="end"
            >
              <Offcanvas.Header closeButton>
                <Offcanvas.Title id={`offcanvasNavbarLabel-expand-${expand}`}>
                  Offcanvas
                </Offcanvas.Title>
              </Offcanvas.Header>
              <Offcanvas.Body>
                <Nav className="justify-content-end flex-grow-1 pe-3">
                
                  <Nav.Link href="#action1">Home</Nav.Link>
                  <Nav.Link href="Gallery">Gallery</Nav.Link>
                  <Nav.Link href="TopList">TopList</Nav.Link>
                  <Nav.Link href="FetchData">Fetch</Nav.Link>
                  <Nav.Link href="Dashboard">testLogin</Nav.Link>
                  <NavDropdown
                    title="Login"
                    id={`offcanvasNavbarDropdown-expand-${expand}`}
                  >
                    <Login/>
                  </NavDropdown>
                <Nav.Link href="SignUp">SignUp</Nav.Link>
                  {/* <NavDropdown
                    title="Dropdown"
                    id={`offcanvasNavbarDropdown-expand-${expand}`}
                  >
                    
                    <NavDropdown.Item href="#action3">Action</NavDropdown.Item>
                    <NavDropdown.Item href="#action4">Another action</NavDropdown.Item>
                    <NavDropdown.Divider />
                    <NavDropdown.Item href="#action5">Something else here</NavDropdown.Item>
                  </NavDropdown> */}
                </Nav>
              </Offcanvas.Body>
            </Navbar.Offcanvas>
          </Container>
        </Navbar>
      ))}
    </>
  );
}

export default NavMenu;
// import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
// import { Link } from 'react-router-dom';
// import './NavMenu.css';

// export class NavMenu extends Component {
//   static displayName = NavMenu.name;

//   constructor (props) {
//     super(props);

//     this.toggleNavbar = this.toggleNavbar.bind(this);
//     this.state = {
//       collapsed: true
//     };
//   }

//   toggleNavbar () {
//     this.setState({
//       collapsed: !this.state.collapsed
//     });
//   }

//   render() {
//     return (
//       <header>
//         <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
//           <NavbarBrand tag={Link} to="/">ArtGallery</NavbarBrand>
//           <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
//           <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
//             <ul className="navbar-nav flex-grow">
//               <NavItem>
//                 <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
//               </NavItem>
//               <NavItem>
//                 <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
//               </NavItem>
//               <NavItem>
//                 <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
//               </NavItem>
//             </ul>
//           </Collapse>
//         </Navbar>
//       </header>
//     );
//   }
// }







