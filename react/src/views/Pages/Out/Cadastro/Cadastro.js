import React, { Component } from 'react';
import Axios from 'axios';
import { Button, Card, CardBody, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row, Modal } from 'reactstrap';

class Cadastro extends Component {
  state = {
    nome: '',
    email: '',
    senha: '',
    checkSenha: '',
    modalAberto: false,
  }
  ErroSenha = () => {
    this.setState({ erroSenhas : 'Senhas não sao iguais'})
  }
  efetuaCadastro = async (event) => {
    event.preventDefault();
    
    if (this.state.senha !== this.state.checkSenha) {
      await this.ErroSenha();
    }

    const body = { nome: this.state.nome, email: this.state.email, senha: this.state.senha, checkSenha: this.state.checkSenha};

    Axios.post('https://hydroponics-tcc.azurewebsites.net/api/Usuario', body)
      .then(response => {
        if (response.status === 200) {
        }
      }).catch(err => {
        if (err.status === 400) {
          console.log(err.message)
        }
      })
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
            <Col md="9" lg="7" xl="6">
              <Card className="mx-4">
                <CardBody className="p-4">
                  <Form onSubmit={this.efetuaCadastro}>
                    <h1>Cadastro</h1>
                    <p className="text-muted">Crie sua conta</p>
                    <InputGroup className="mb-3">
                      <InputGroupAddon addonType="prepend">
                        <InputGroupText>
                          <i className="icon-user"></i>
                        </InputGroupText>
                      </InputGroupAddon>
                      <Input 
                        type="text" 
                        placeholder="Nome" 
                        autoComplete="nome"
                        name="nome"
                        value={this.state.nome}
                        onChange={this.atualizaStateCampo.bind(this)}
                      />
                    </InputGroup>
                    <InputGroup className="mb-3">
                      <InputGroupAddon addonType="prepend">
                        <InputGroupText>@</InputGroupText>
                      </InputGroupAddon>
                      <Input 
                        type="text" 
                        placeholder="E-mail" 
                        autoComplete="e-mail"
                        name="email"
                        value={this.state.email}
                        onChange={this.atualizaStateCampo.bind(this)}
                      />
                    </InputGroup>
                    <InputGroup className="mb-3">
                      <InputGroupAddon addonType="prepend">
                        <InputGroupText>
                          <i className="icon-lock"></i>
                        </InputGroupText>
                      </InputGroupAddon>
                      <Input 
                        type="password" 
                        placeholder="Senha" 
                        autoComplete="nova-senha"
                        name="senha"
                        value={this.state.senha}
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
                        placeholder="Repita a senha" 
                        autoComplete="nova-senha" 
                        name="checkSenha"
                        value={this.state.checkSenha}
                        onChange={this.atualizaStateCampo.bind(this)}
                      />
                    </InputGroup>
                    <Button 
                      color="success" 
                      block 
                      type="button" 
                      className="btn btn-primary" 
                      data-toggle="modal" 
                      data-target="#ExemploModalCentralizado"
                    >
                      Cadastrar
                    </Button>
                  </Form>
                  <div className="modal fade" id="ExemploModalCentralizado" tabindex="-1" role="dialog" aria-labelledby="TituloModalCentralizado" aria-hidden="true">
                    <div className="modal-dialog modal-dialog-centered" role="document">
                      <div className="modal-content">
                        <div className="modal-header">
                          <h5 className="modal-title" id="TituloModalCentralizado">Cadastro efetuado com sucesso.</h5>
                        </div>
                        <div className="modal-footer">
                          <button type="button" className="btn btn-primary text center">Prosseguir</button>
                        </div>
                      </div>
                    </div>
                  </div>
                </CardBody>
              </Card>
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

export default Cadastro;
