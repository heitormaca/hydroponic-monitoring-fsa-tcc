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
            <strong>Cadastro de plantação</strong>
          </CardHeader>
          <CardBody>
            <Form action="" method="post">
              <FormGroup row className="my-0">
              <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="select">Bancada</Label>
                    <Input type="select" name="select" id="select">
                      <option value="0">Selecione uma opção</option>
                      <option value="1">Bancada 01</option>
                      <option value="2">Bancada 02</option>
                      <option value="3">Bancada 03</option>
                      <option value="3">Bancada 04</option>
                      <option value="3">Bancada 05</option>
                    </Input>
                    <FormText className="help-block">Escolha a bancada que deseja vincular à sua plantação</FormText> 
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label>Nome da plantação</Label>
                    <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Plantação-01"/>
                    <FormText className="help-block">Insira o nome da plantação</FormText>  
                  </FormGroup>
                </Col>
              </FormGroup>
              <FormGroup row className="my-0">
              <Col xs="6">
                  <FormGroup>
                    <Label>Tipo de semeio</Label>
                    <Input type="text" id="type-sem" placeholder="Ex: Alface" />
                    <FormText className="help-block">Insira o tipo de semeio</FormText>  
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="date-input">Data de finalização</Label>
                    <Input type="date" id="date-input-f" name="date-input-f" placeholder="date" />
                    <FormText className="help-block">Insira a data prevista para a finalização da plantação</FormText>  
                  </FormGroup>
                </Col>
              </FormGroup>
              <FormGroup row className="my-0">
                <Col xs="6">
                  <FormGroup>
                    <Label>Valor máximo de PH</Label>
                    <Input type="number" id="maxPH" name="maxPH" placeholder="Ex: 5" min="0" max="14" step="0.1" />
                    <FormText className="help-block">Insira o valor máximo de PH da solução</FormText>  
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label>Valor mínimo de PH</Label>
                    <Input type="number" id="minPH" name="minPH" placeholder="Ex: 3" min="0" max="14" step="0.1" />
                    <FormText className="help-block">Insira o valor mínimo de PH da solução</FormText>  
                  </FormGroup>
                </Col>
              </FormGroup>
              <FormGroup row className="my-0">
                <Col xs="6">
                  <FormGroup>
                    <Label>Valor máximo de EC</Label>
                    <Input type="number" id="maxEC" name="maxEC" placeholder="Ex: 10" min="0" max="100" step="0.1" />
                    <FormText className="help-block">Insira o valor máximo de EC da solução</FormText>  
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label>Valor mínimo de EC</Label>
                    <Input type="number" id="minEC" name="minEC"placeholder="Ex: 5" min="0" max="100" step="0.1" />
                    <FormText className="help-block">Insira o valor mínimo de EC da solução</FormText>  
                  </FormGroup>
                </Col>
              </FormGroup>
              <FormGroup row className="my-0">
                <Col xs="6">
                  <FormGroup>
                    <Label>Temperatura máxima (°C)</Label>
                    <Input type="number" id="maxTemp" name="maxTemp" placeholder="Ex: 30" min="0" max="100" step="0.1"/>
                    <FormText className="help-block">Insira a temperatura máxima da bancada</FormText>   
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label>Temperatura mínima (°C)</Label>
                    <Input type="number" id="minTemp" name="minTemp" placeholder="Ex: 15" min="0" max="100" step="0.1"/>
                    <FormText className="help-block">Insira a temperatura mínima da bancada</FormText>  
                  </FormGroup>
                </Col>
              </FormGroup>
              <FormGroup row className="my-0">
                <Col xs="6">
                  <FormGroup>
                    <Label>Temperatura máxima (°C)</Label>
                    <Input type="number" id="maxTemp" name="maxTemp" placeholder="Ex: 30" min="0" max="100" step="0.1"/>
                    <FormText className="help-block">Insira a temperatura máxima da solução</FormText>   
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label>Temperatura mínima (°C)</Label>
                    <Input type="number" id="minTemp" name="minTemp" placeholder="Ex: 15" min="0" max="100" step="0.1"/>
                    <FormText className="help-block">Insira a temperatura mínima da solução</FormText>  
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
