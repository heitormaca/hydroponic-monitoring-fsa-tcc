import React, { Component } from 'react';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';
import { Link } from 'react-router-dom';

class Login extends Component {
  render() {
    return (
      <div className="app flex-row align-items-center">
        <Container>
          <Row className="justify-content-center">
            <Col md="8">
              <CardGroup>
                <Card className="p-4">
                  <CardBody>
                    <Form>
                      <h1>Login</h1>
                      <p className="text-muted">Entre com a sua conta</p>
                      <InputGroup className="mb-3">
                        <InputGroupAddon addonType="prepend">
                          <InputGroupText>
                            <i className="icon-user"></i>
                          </InputGroupText>
                        </InputGroupAddon>
                        <Input type="text" placeholder="Usuário" autoComplete="usuario" />
                      </InputGroup>
                      <InputGroup className="mb-4">
                        <InputGroupAddon addonType="prepend">
                          <InputGroupText>
                            <i className="icon-lock"></i>
                          </InputGroupText>
                        </InputGroupAddon>
                        <Input type="password" placeholder="Senha" autoComplete="senha-atual" />
                      </InputGroup>
                      <Row>
                        <Col xs="6">
                          <Link to={'/dashboard'}><Button color="primary" className="px-4">Entrar</Button></Link>
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
