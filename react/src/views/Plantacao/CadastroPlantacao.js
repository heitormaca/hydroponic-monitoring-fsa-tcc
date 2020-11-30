import React, { useEffect, useState } from 'react';
import { FormGroup, Col, Card, Input, CardBody, CardHeader, Form, Label, FormText, Button } from 'reactstrap';
import axiosInstance from '../../utils/request';

const CadastroPlantacao = () => {
  const [bancadas, setBancadas] = useState([]);
  const [bancadaSelecionada, setBancadaSelecionada] = useState('');
  const [semeio, setSemeio] = useState('');
  const [dataFim, setDataFim] = useState('');
  const [phMax, setPhMax] = useState('');
  const [phMin, setPhMin] = useState('');
  const [ecMax, setEcMax] = useState('');
  const [ecMin, setEcMin] = useState('');
  const [TempBancMax, setTempBancMax] = useState('');
  const [TempBancMin, setTempBancMin] = useState('');
  const [TempSolMax, setTempSolMax] = useState('');
  const [TempSolMin, setTempSolMin] = useState('');

  useEffect(() => {
    const getBancadas = async () => {
      try {
        // 'buscar bancadas'
        const response = await axiosInstance.get(`Bancada`);

        // 'modifico o estado das bancadas, setBancadas(listagem)
        setBancadas(response.data);

      } catch (err) {
        console.error('erro', err)
      }
    }
    getBancadas();
  }, [])

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const obj = { idBancada: bancadaSelecionada, semeio, dataFim, phMax, phMin, ecMax, ecMin, TempBancMax, TempBancMin, TempSolMax, TempSolMin };

      const response = await axiosInstance.post('Plantacao', obj);

      if (response.status === 200) {
        setSemeio('');
        setDataFim('');
        setPhMax('');
        setPhMin('');
        setEcMax('');
        setEcMin('');
        setTempBancMax('');
        setTempBancMin('');
        setTempSolMax('');
        setTempSolMin('');
        setBancadaSelecionada('');
        
      }
    } catch (err) {
      console.log(err, 'falha ao enviar');
    }
  }

  return <Card>
    <CardHeader>
      <strong>Cadastro de plantação</strong>
    </CardHeader>
    <CardBody>
      <Form onSubmit={handleSubmit}>
        <FormGroup row className="my-0">
        <Col xs="6" centered>
            <FormGroup>
              <Label htmlFor="select">Bancada</Label>
              <Input type="select" name="select" id="select" value={bancadaSelecionada} onChange={({ target: { value } }) => { setBancadaSelecionada(value) }} >
                <option value="0">Selecione uma opção</option>
                {bancadas?.map((item) => (<option key={item.idBancada} value={item.idBancada}>{item.nome}</option>))}
              </Input>
              <FormText className="help-block">Escolha a bancada que deseja vincular à sua plantação</FormText> 
            </FormGroup>
          </Col>
        </FormGroup>
        <FormGroup row className="my-0">
        <Col xs="6">
            <FormGroup>
              <Label>Tipo de semeio</Label>
              <Input type="text" id="type-sem" placeholder="Ex: Alface" value={semeio} onChange={({ target: { value } }) => setSemeio(value)} />
              <FormText className="help-block">Insira o tipo de semeio</FormText>  
            </FormGroup>
          </Col>
          <Col xs="6">
            <FormGroup>
              <Label htmlFor="date-input">Data de finalização</Label>
              <Input type="date" id="date-input-f" name="date-input-f" placeholder="date" value={dataFim} onChange={({ target: { value } }) => setDataFim(value)} />
              <FormText className="help-block">Insira a data prevista para a finalização da plantação</FormText>  
            </FormGroup>
          </Col>
        </FormGroup>
        <FormGroup row className="my-0">
          <Col xs="6">
            <FormGroup>
              <Label>Valor máximo de PH</Label>
              <Input type="number" id="maxPH" name="maxPH" placeholder="Ex: 10" min="0" max="14" step="0.1" value={phMax} onChange={({ target: { value } }) => setPhMax(value)} />
              <FormText className="help-block">Insira o valor máximo de PH da solução</FormText>  
            </FormGroup>
          </Col>
          <Col xs="6">
            <FormGroup>
              <Label>Valor mínimo de PH</Label>
              <Input type="number" id="minPH" name="minPH" placeholder="Ex: 4" min="0" max="14" step="0.1" value={phMin} onChange={({ target: { value } }) => setPhMin(value)} />
              <FormText className="help-block">Insira o valor mínimo de PH da solução</FormText>  
            </FormGroup>
          </Col>
        </FormGroup>
        <FormGroup row className="my-0">
          <Col xs="6">
            <FormGroup>
              <Label>Valor máximo de EC</Label>
              <Input type="number" id="maxEC" name="maxEC" placeholder="Ex: 4" min="0" max="5" step="0.1" value={ecMax} onChange={({ target: { value } }) => setEcMax(value)} />
              <FormText className="help-block">Insira o valor máximo de EC da solução</FormText>  
            </FormGroup>
          </Col>
          <Col xs="6">
            <FormGroup>
              <Label>Valor mínimo de EC</Label>
              <Input type="number" id="minEC" name="minEC"placeholder="Ex: 2" min="0" max="5" step="0.1" value={ecMin} onChange={({ target: { value } }) => setEcMin(value)} />
              <FormText className="help-block">Insira o valor mínimo de EC da solução</FormText>  
            </FormGroup>
          </Col>
        </FormGroup>
        <FormGroup row className="my-0">
          <Col xs="6">
            <FormGroup>
              <Label>Temperatura máxima (°C)</Label>
              <Input type="number" id="maxTemp" name="maxTemp" placeholder="Ex: 30" min="0" max="100" step="0.1" value={TempBancMax} onChange={({ target: { value } }) => setTempBancMax(value)} />
              <FormText className="help-block">Insira a temperatura máxima da bancada</FormText>   
            </FormGroup>
          </Col>
          <Col xs="6">
            <FormGroup>
              <Label>Temperatura mínima (°C)</Label>
              <Input type="number" id="minTemp" name="minTemp" placeholder="Ex: 15" min="0" max="100" step="0.1" value={TempBancMin} onChange={({ target: { value } }) => setTempBancMin(value)} />
              <FormText className="help-block">Insira a temperatura mínima da bancada</FormText>  
            </FormGroup>
          </Col>
        </FormGroup>
        <FormGroup row className="my-0">
          <Col xs="6">
            <FormGroup>
              <Label>Temperatura máxima (°C)</Label>
              <Input type="number" id="maxTemp" name="maxTemp" placeholder="Ex: 30" min="0" max="100" step="0.1" value={TempSolMax} onChange={({ target: { value } }) => setTempSolMax(value)} />
              <FormText className="help-block">Insira a temperatura máxima da solução</FormText>   
            </FormGroup>
          </Col>
          <Col xs="6">
            <FormGroup>
              <Label>Temperatura mínima (°C)</Label>
              <Input type="number" id="minTemp" name="minTemp" placeholder="Ex: 15" min="0" max="100" step="0.1" value={TempSolMin} onChange={({ target: { value } }) => setTempSolMin(value)} />
              <FormText className="help-block">Insira a temperatura mínima da solução</FormText>  
            </FormGroup>
          </Col>
        </FormGroup>
        <Button size="sm" color="primary">CADASTRAR</Button>
      </Form>
    </CardBody>
  </Card>
}

export default CadastroPlantacao;
