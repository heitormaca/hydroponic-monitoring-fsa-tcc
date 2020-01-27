import React, { Component } from 'react';
import { parseJwt } from '../../../../services/auth'
import Axios from 'axios';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';
import { Link } from 'react-router-dom';

class Login extends Component {

  constructor(props){
    super(props);
    this.state = {
      email : '',
      senha : '',
      erroMensagem : '',
      isLoading : false
    }
  }
  efetuaLogin(event){
    event.preventDefault();
    this.setState({erroMensagem : ''})
    this.setState({isLoading : true });
    Axios.post(
      'https://localhost:5001/api/Login',
      {  email : this.state.email, senha : this.state.senha })
    .then(data => {     
      if (data.status === 200){
      localStorage.setItem('autenticarlogin', data.data.token)
      this.setState({isLoading : false});
      var base64 = localStorage.getItem('autenticarlogin').split('.')[1];
      this.props.history.push('/home')
    }})
    .catch(erro => {
      this.setState({erroMensagem : 'E-mail ou senha inválidos!'})
      this.setState({isLoading : false});
    });
  }
  atualizaStateCampo(event){
    this.setState({ [event.target.name] : event.target.value })
    this.setState()
  }
  render() {
    return (
      <div className="app flex-row align-items-center">
        <Container>
          <Row className="justify-content-center">
            <Col md="8">
              <CardGroup>
                <Card className="p-4">
                  <CardBody>
                    <Form action="" method="post">
                      <h1>Login</h1>
                      <p className="text-muted">Entre com a sua conta</p>
                      <InputGroup className="mb-3">
                        <InputGroupAddon addonType="prepend">
                          <InputGroupText>
                            <i className="icon-user"></i>
                          </InputGroupText>
                        </InputGroupAddon>
                        <Input 
                          type="text" 
                          placeholder="E-mail" 
                          autoComplete="email" 
                          name="email"
                          value={this.state.email}
                          onChange={this.atualizaStateCampo.bind(this)}
                        />
                      </InputGroup>
                      <InputGroup className="mb-4">
                        <InputGroupAddon addonType="prepend">
                          <InputGroupText>
                            <i className="icon-lock"></i>
                          </InputGroupText>
                        </InputGroupAddon>
                        <Input 
                          type="password" 
                          placeholder="Senha" 
                          autoComplete="senha-atual"
                          name="senha"
                          value={this.state.senha}
                          onChange={this.atualizaStateCampo.bind(this)} 
                        />
                      </InputGroup>
                      <Row>
                        <Col xs="6">
                          <p color="alert">{this.state.erroMensagem}</p>
                          {
                            this.state.isLoading === false &&
                            <Button color="primary" className="px-4">Entrar</Button>
                          }
                          {
                            this.state.isLoading === true &&
                            <Button type="submit" disabled>Carregando...</Button>   
                          }
                        </Col>
                        <Col xs="6" className="text-right">
                          <Link to={'/esquecisenha'}><Button color="link" className="px-0">Esqueceu a senha?</Button></Link>
                        </Col>
                      </Row>
                    </Form>
                  </CardBody>
                </Card>
                <Card className="text-white bg-primary py-5 d-md-down-none" style={{ width: '44%' }}>
                  <CardBody className="text-center">
                    <div>
                      <h2>Inscreva-se</h2>
                      <p>Seja bem vindo ao sitema de monitoramento de estufas hidroponicas. Se você é novo por aqui clique no botão a baixo e faça seu cadastro.</p>
                      <Link to="/register">
                        <Link to={'/cadastro'}><Button color="primary" className="mt-3" active tabIndex={-1}>Cadastre-se!</Button></Link>
                      </Link>
                    </div>
                  </CardBody>
                </Card>
              </CardGroup>
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

export default Login;
