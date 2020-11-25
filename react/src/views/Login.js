import React, { Component } from 'react';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';
import { Link } from 'react-router-dom';
import axiosInstance from '../utils/request';

class Login extends Component {
  state = {
    email: '',
    senha: '',
    erroMensagem: '',
    isLoading: false
  }

  efetuaLogin = async (event) => {
    event.preventDefault();
    await this.setState({ erroMensagem: '' });
    await this.setState({ isLoading: true });

    const body = { email: this.state.email, senha: this.state.senha };

    axiosInstance.post('Produtor/Login', body, { headers: {} })
      .then(async (data) => {
        if (data.status === 200) {
          localStorage.setItem('autenticarlogin', data.data.token)
          axiosInstance.defaults.headers['Authorization'] = `Bearer ${localStorage.getItem('autenticarlogin')}`
          await this.setState({ isLoading: false });
          this.props.history.push('/dashboard')
        }
      })
      .catch(erro => {
        this.setState({ erroMensagem: 'E-mail ou senha inválidos!' })
        this.setState({ isLoading: false });
      });
  }
  atualizaStateCampo(event) {
    this.setState({ [event.target.name]: event.target.value })
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
                    <Form onSubmit={this.efetuaLogin}>
                      <h1>Login</h1>
                      <p className="text-muted">Entre com a sua conta</p>
                      <InputGroup className="mb-3">
                        <InputGroupAddon addonType="prepend">
                          <InputGroupText>
                            <i className="icon-envelope"></i>
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
                        <Col xs="12">
                          <p style={{ color: 'red' }}>{this.state.erroMensagem}</p>
                        </Col>
                        <Col xs="6">
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
                          <Link to={'/esqueci-senha'}><Button color="link" className="px-0">Esqueceu a senha?</Button></Link>
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
                      <Link to={'/cadastro'}>
                        <Button color="primary" className="mt-3" active tabIndex={-1}>
                          Cadastre-se!
                          </Button>
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
