import React, { Component } from 'react';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';
import { Link } from 'react-router-dom';

class Login extends Component {
  render() {
    return (
      <div className="app flex-row align-items-center">
        <Container>
          <Row className="justify-content-center">
            <Col md="5">
              <CardGroup>
                <Card className="p-6">
                  <CardBody>
                    <Form>
                      <h1>Esqueci a senha</h1>
                      <p className="text-muted">Informe o seu e-mail cadastrado para receber um nova senha.</p>
                      <InputGroup className="mb-3">
                        <InputGroupAddon addonType="prepend">
                          <InputGroupText>
                            <i className="icon-envelope"></i>
                          </InputGroupText>
                        </InputGroupAddon>
                        <Input type="text" placeholder="Ex: usuario@email.com " autoComplete="email" />
                      </InputGroup>
                      <Row>
                        <Col xs="6" className="center">
                          <Link to={'/login'}><Button color="success" className="px-4">Enviar</Button></Link>
                        </Col>
                      </Row>
                    </Form>
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
