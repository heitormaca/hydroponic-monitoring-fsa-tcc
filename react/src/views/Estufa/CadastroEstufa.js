import React, { useState } from 'react';
import { FormGroup, Col, Card, Input, CardBody, CardHeader, Form, Label, FormText, Button } from 'reactstrap';
import axiosInstance from '../../utils/request';

const CadastroEstufa = () => {
  const [nome, setNome] = useState('');
  const [localizacao, setLocalizacao] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const obj = { nome, localizacao };

      const response = await axiosInstance.post('Estufa', obj);

      if (response.status === 200) {
        setNome('');
        setLocalizacao('');    
      }
    } catch (err) {
      console.log(err, 'falha ao enviar');
    }
  }

  return <Card>
    <CardHeader>
      <strong>Cadastro de estufa</strong>
    </CardHeader>
    <CardBody>
      <Form onSubmit={handleSubmit}>
        <FormGroup row className="my-0">
          <Col xs="6">
            <FormGroup>
              <Label htmlFor="nf-name">Nome</Label>
              <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Estufa-01" value={nome} onChange={({ target: { value } }) => setNome(value)} />
              <FormText className="help-block">Insira o nome da estufa</FormText>
            </FormGroup>
          </Col>
          <Col xs="6">
            <FormGroup>
              <Label htmlFor="nf-location">Localização</Label>
              <Input type="text" id="nf-location" name="nf-location" placeholder="Ex: Setor A" value={localizacao} onChange={({ target: { value } }) => setLocalizacao(value)} />
              <FormText className="help-block">Insira a localização da sua estufa.</FormText>
            </FormGroup>
          </Col>
        </FormGroup>
        <Button className="my-3" size="sm" color="primary">CADASTRAR</Button>
      </Form>
    </CardBody>
  </Card>
}

export default CadastroEstufa;
