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


class CadastroEstufa extends Component {

  render() {
    return (
      <div>
        <Card>
          <CardHeader>
            <strong>Cadastro de estufa</strong>
          </CardHeader>
          <CardBody>
            <Form action="" method="post">
              <FormGroup row className="my-0">
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="nf-name">Nome</Label>
                    <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Estufa-01" />
                    <FormText className="help-block">Insira o nome da estufa</FormText>
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="nf-location">Localização</Label>
                    <Input type="text" id="nf-location" name="nf-location" placeholder="Ex: Setor A" />
                    <FormText className="help-block">Insira a localização da sua estufa.</FormText>
                  </FormGroup>
                </Col>
              </FormGroup>
            </Form>
            <Button className="my-3" type="submit" size="sm" color="primary">CADASTRAR</Button>
          </CardBody>
        </Card>     
      </div>
    );
  }
}

export default CadastroEstufa;
