import React, { Component } from 'react';
import { Button, Card, CardBody, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row, Modal, ModalFooter, ModalBody, Alert } from 'reactstrap';
import axiosInstance from '../utils/request';

class Cadastro extends Component {
  state = {
    nome: '',
    email: '',
    senha: '',
    checkSenha: '',
    erro: '',
    showError: false,
    modalAberto: false,
  }

  efetuaCadastro = async (event) => {
    event.preventDefault();
    try {
      if (this.state.senha !== this.state.checkSenha) {
        throw new Error("As senhas não são iguais");
      }

      const body = { nome: this.state.nome, email: this.state.email, senha: this.state.senha, checkSenha: this.state.checkSenha };
      const response = await axiosInstance.post('Produtor', body);

      if (response.status === 200) {
        this.toggleModal();
      }

    } catch (err) {
      this.setState({ showError: true, erro: err.message });
    }
  }

  prosseguirCadastro = () => {
    const { history } = this.props;

    history.push('/login');

    this.toggleModal();
  }

  toggleModal = () => this.setState({ modalAberto: !this.state.modalAberto });

  dismissError = () => this.setState({ erro: '', showError: false });

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
                    <Button color="success" block className="btn btn-primary" data-toggle="modal" data-target="#ExemploModalCentralizado">
                      Cadastrar
                    </Button>
                  </Form>
                  <Modal isOpen={this.state.modalAberto} toggle={this.toggleModal} centered>
                    <ModalBody>Cadastro efetuado com sucesso</ModalBody>
                    <ModalFooter>
                      <Button color="primary" onClick={this.prosseguirCadastro}>Prosseguir</Button>
                    </ModalFooter>
                  </Modal>
                </CardBody>
                <Alert isOpen={this.state.showError} color="danger" toggle={this.state.dismissError}>
                  {this.state.erro}
                </Alert>
              </Card>
            </Col>
          </Row>

        </Container>

      </div>
    );
  }
}

export default Cadastro;
