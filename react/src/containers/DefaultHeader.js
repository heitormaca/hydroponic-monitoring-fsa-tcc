import React, { Component } from 'react';
import { UncontrolledDropdown, DropdownItem, DropdownMenu, DropdownToggle, Nav, NavItem } from 'reactstrap';
import PropTypes from 'prop-types';
import { AppNavbarBrand, AppSidebarToggler } from '@coreui/react';
import logo from '../assets/img/brand/logo.svg'
import sygnet from '../assets/img/brand/sygnet.svg'
import { Link } from 'react-router-dom';

const propTypes = {
  children: PropTypes.node,
};

const defaultProps = {};

class DefaultHeader extends Component {
  render() {

    // eslint-disable-next-line
    const { children, ...attributes } = this.props;

    return (
      <React.Fragment>
        <AppSidebarToggler className="d-lg-none" display="md" mobile />
        <AppNavbarBrand
          full={{ src: logo, width: 89, height: 25, alt: 'CoreUI Logo' }}
          minimized={{ src: sygnet, width: 30, height: 30, alt: 'CoreUI Logo' }}
        />
        <AppSidebarToggler className="d-md-down-none" display="lg" />
        <Nav className="ml-auto" navbar>
          <UncontrolledDropdown nav direction="down">
            <DropdownToggle nav>
              <img src={'../assets/img/users/fazendeiro.jpg'} className="img-avatar" alt="admin@bootstrapmaster.com" />
            </DropdownToggle>
            <DropdownMenu right>
              <DropdownItem header tag="div" className="text-center"><strong>Conta</strong></DropdownItem>
              <Link to={'/conta/perfil'}><DropdownItem><i className="fa fa-user"></i> Perfil</DropdownItem></Link>
              <Link to={'/conta/alterar-senha'}><DropdownItem><i className="fa fa-lock"></i> Alterar senha</DropdownItem></Link>
              <Link to={'/login'}><DropdownItem><i className="fa fa-power-off"></i> Sair</DropdownItem></Link>
            </DropdownMenu>
          </UncontrolledDropdown>
        </Nav>
      </React.Fragment>
    );
  }
}

DefaultHeader.propTypes = propTypes;
DefaultHeader.defaultProps = defaultProps;

export default DefaultHeader;
