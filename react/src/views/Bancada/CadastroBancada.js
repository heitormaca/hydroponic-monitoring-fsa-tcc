import React, { Component } from 'react';
import { 
  FormGroup, 
  Col, 
  Card, 
  Input,
  CardBody,
  CardHeader,
  Form,
  Label,
  FormText,
  Button,
} from 'reactstrap';

class CadastroBancada extends Component {

  render() {
    return (
      <div>
        <Card>
          <CardHeader>
            <strong>Cadastro de bancada</strong>
          </CardHeader>
          <CardBody>
            <Form action="" method="post">
              <FormGroup row className="my-0">
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="select">Estufa</Label>
                    <Input type="select" name="select" id="select">
                      <option value="0">Selecione uma opção</option>
                      <option value="1">Estufa 01</option>
                      <option value="2">Estufa 02</option>
                      <option value="3">Estufa 03</option>
                      <option value="3">Estufa 04</option>
                      <option value="3">Estufa 05</option>
                    </Input>
                    <FormText className="help-block">Escolha a estufa que deseja vincular à sua bancada</FormText> 
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="select">Dispositivo</Label>
                    <Input type="select" name="select" id="select">
                      <option value="0">Selecione uma opção</option>
                      <option value="1">Dispositivo 01</option>
                      <option value="2">Dispositivo 02</option>
                      <option value="3">Dispositivo 03</option>
                      <option value="3">Dispositivo 04</option>
                      <option value="3">Dispositivo 05</option>
                    </Input>
                    <FormText className="help-block">Escolha o dispositivo que deseja vincular à sua bancada</FormText> 
                  </FormGroup>
                </Col>
              </FormGroup>
              <FormGroup row className="my-0">
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="nf-name">Nome</Label>
                    <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Bancada-01" />
                    <FormText className="help-block">Insira o nome da bancada</FormText>
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="nf-location">Localização</Label>
                    <Input type="text" id="nf-location" name="nf-location" placeholder="Ex: Setor A6" />
                    <FormText className="help-block">Insira a localização da sua bancada.</FormText>
                  </FormGroup>
                </Col>
              </FormGroup>
            </Form>
            <Button type="submit" size="sm" color="primary">CADASTRAR</Button>
          </CardBody>
        </Card>
      </div>       
    );
  }
}

export default CadastroBancada;
