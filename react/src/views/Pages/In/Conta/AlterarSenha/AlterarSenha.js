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


class AlterarSenha extends Component {

  render() {
    return (
      <div>
        <Card>
          <CardHeader>
            <strong>Alterar senha</strong>
          </CardHeader>
          <CardBody>
            <p className="text-muted">Insira os dados a seguir para realizar a alteração de senha.</p>
            <Form action="" method="post">
              <FormGroup row className="my-0">
                <Col xs="4">
                  <FormGroup>
                    <Label htmlFor="nf-name">Senha atual</Label>
                    <Input type="password" id="nf-current-password" name="nf-current-password" />
                    <FormText className="help-block">Insira a sua senha atual</FormText>
                  </FormGroup>
                </Col>
                <Col xs="4">
                  <FormGroup>
                    <Label htmlFor="nf-name">Nova senha</Label>
                    <Input type="password" id="nf-new-password" name="nf-new-password" />
                    <FormText className="help-block">Insira a sua nova senha</FormText>
                  </FormGroup>
                </Col>
                <Col xs="4">
                  <FormGroup>
                    <Label htmlFor="nf-name">Confirmação de nova senha</Label>
                    <Input type="password" id="nf-confirm-new-password" name="nf-confirm-new-password" />
                    <FormText className="help-block">Insira a sua nova senha novamente</FormText>
                  </FormGroup>
                </Col>
              </FormGroup>
            </Form>
            <Button type="submit" size="sm" color="primary">ALTERAR</Button>
          </CardBody>
        </Card>     
      </div>
    );
  }
}

export default AlterarSenha;
