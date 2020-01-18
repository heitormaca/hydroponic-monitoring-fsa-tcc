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
                    <Label>Nome da bancada</Label>
                    <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Bancada-01" />
                    <FormText className="help-block">Insira o nome da bancada</FormText>  
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label>Tipo de semeio</Label>
                    <Input type="text" id="type-sem" placeholder="Ex: Alface" />
                    <FormText className="help-block">Insira o tipo de semeio</FormText>  
                  </FormGroup>
                </Col>
              </FormGroup>
              <FormGroup row className="my-0">
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="date-input">Date de inicio</Label>
                    <Input type="date" id="date-input-i" name="date-input-i" placeholder="date" />
                    <FormText className="help-block">Insira a data de inicio da bancada</FormText>  
                  </FormGroup>
                </Col>
                <Col xs="6">
                  <FormGroup>
                    <Label htmlFor="date-input">Data de fim</Label>
                    <Input type="date" id="date-input-f" name="date-input-f" placeholder="date" />
                    <FormText className="help-block">Insira a data de fim da bancada</FormText>  
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
