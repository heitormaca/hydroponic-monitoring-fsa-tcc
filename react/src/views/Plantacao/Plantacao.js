import React, { useEffect, useState } from 'react';
import { Card, CardBody, CardHeader, Col, Row, Table, CardTitle } from 'reactstrap';
import { useRouteMatch } from 'react-router-dom';
import moment from "moment";
import axiosInstance from '../../utils/request';
import { Legend, ReferenceLine, LineChart, CartesianGrid, XAxis, YAxis, Line, Tooltip, ResponsiveContainer } from 'recharts';

const Plantacao = () => {
  const { plantacaoId } = useRouteMatch().params;
  const [plantacao, setPlantacao] = useState(null);
  const [charts, setCharts] = useState(null);
  const sensorTempBancData = charts?.map((item) => ({ date: item.date, value: item.sensorTempBanc.value })) || []
  const sensorTempSolData = charts?.map((item) => ({ date: item.date, value: item.sensorTempSol.value })) || []
  const sensorPhData = charts?.map((item) => ({ date: item.date, value: item.sensorPh.value })) || []
  const sensorEcData = charts?.map((item) => ({ date: item.date, value: item.sensorEc.value })) || []
  const tooltopEc = (value) => [value + ' mS/cm', 'Valor'];
  const tooltipFormatter = (value) => [value, 'Valor'];
  const tooltipCelsius = (value) => [value + ' °C', 'Valor'];
  const tooltipLabelFormatter = (_) => {
    return moment(_).format("DD/MM/YYYY HH:mm");
  };

  const legendFormatter = (value) => {
    return "Valor";
  }

  useEffect(() => {
    const getPlantacao = async () => {
      try {
        // 'buscar plantação'
        const plantacaoResponse = await axiosInstance.get(`Plantacao/${plantacaoId}`);
        const chartsResponse = await axiosInstance.get(`Plantacao/${plantacaoId}/Graphics`)
        setPlantacao(plantacaoResponse.data);
        setCharts(chartsResponse.data);
      } catch (err) {
        console.error('erro', err)
      }
    }
    getPlantacao();
  }, [plantacaoId]);

  const CustomizedAxisTick = ({ x, y, payload }) => {
    const value = moment(payload.value).format("DD/MM/YYYY HH:mm");

    return (
      <g transform={`translate(${x},${y})`}>
        <text
          x={0}
          y={0}
          dy={16}
          textAnchor="end"
          fill="#666"
          transform="rotate(-40)"
        >
          {value}
        </text>
      </g>
    );
  };

  return <Row>
    <Col xs="12">
      <Card>
        <CardHeader>
          <strong>Plantação</strong>
        </CardHeader>
        <CardBody>
          <Table hover bordered striped responsive size="sm">
            <thead>
              <tr>
                <th>Número</th>
                <th>Tipo de semeio</th>
                <th>Data de Criação</th>
                <th>Data de Término</th>
                <th>Bancada</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>{plantacao?.idPlantacao}</td>
                <td>{plantacao?.semeio}</td>
                <td>{moment(plantacao?.dataInicio).format('DD/MM/YYYY')}</td>
                <td>{moment(plantacao?.dataFim).format('DD/MM/YYYY')}</td>
                <td>{plantacao?.nomeBancada}</td>
              </tr>
            </tbody>
          </Table>
        </CardBody>
      </Card>
    </Col>
    <Col>
      <Card>
        <CardHeader>
          <strong>Sensores</strong>
        </CardHeader>
        {charts?.length > 0 ? <>
          <CardBody>
            <Row>
              <Col sm="5">
                <CardTitle><h4>Temperatura da bancada (°C)</h4></CardTitle>
              </Col>
            </Row>
            <div className="chart-wrapper" style={{ height: 400 + 'px', marginTop: 40 + 'px' }}>
              <ResponsiveContainer>
                <LineChart
                  data={sensorTempBancData}
                  margin={{
                    top: 20, right: 50, left: 20, bottom: 5,
                  }}
                >
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="date" tick={<CustomizedAxisTick />}
                    height={120}
                    interval={0} />
                  <YAxis />
                  <Tooltip formatter={tooltipCelsius}
                    labelFormatter={tooltipLabelFormatter} />
                  <Legend formatter={legendFormatter} />
                  <ReferenceLine y={plantacao?.tempBancMax} label="Max" stroke="red" />
                  <ReferenceLine y={plantacao?.tempBancMin} label="Min" stroke="red" />
                  <Line type="monotone" dataKey="value" stroke="#8884d8" />
                </LineChart>
              </ResponsiveContainer>
            </div>
          </CardBody>
          <hr></hr>
          <CardBody>
            <Row>
              <Col sm="5">
                <CardTitle><h4>Temperatura da solução (°C)</h4></CardTitle>
              </Col>
            </Row>
            <div className="chart-wrapper" style={{ height: 400 + 'px', marginTop: 40 + 'px' }}>
              <ResponsiveContainer>
                <LineChart
                  data={sensorTempSolData}
                  margin={{
                    top: 20, right: 50, left: 20, bottom: 5,
                  }}
                >
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="date" tick={<CustomizedAxisTick />}
                    height={120}
                    interval={0} />
                  <YAxis />
                  <Tooltip formatter={tooltipCelsius}
                    labelFormatter={tooltipLabelFormatter} />
                  <Legend formatter={legendFormatter} />
                  <ReferenceLine y={plantacao?.tempSolMax} label="Max" stroke="red" />
                  <ReferenceLine y={plantacao?.tempSolMin} label="Min" stroke="red" />
                  <Line type="monotone" dataKey="value" stroke="#8884d8" />
                </LineChart>
              </ResponsiveContainer>
            </div>
          </CardBody>
          <hr></hr>
          <CardBody>
            <Row>
              <Col sm="5">
                <CardTitle><h4>Medição de PH</h4></CardTitle>
              </Col>
            </Row>
            <div className="chart-wrapper" style={{ height: 400 + 'px', marginTop: 40 + 'px' }}>
              <ResponsiveContainer>
                <LineChart
                  data={sensorPhData}
                  margin={{
                    top: 20, right: 50, left: 20, bottom: 5,
                  }}
                >
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="date" tick={<CustomizedAxisTick />}
                    height={120}
                    interval={0} />
                  <YAxis />
                  <Tooltip formatter={tooltipFormatter}
                    labelFormatter={tooltipLabelFormatter} />
                  <Legend formatter={legendFormatter} />
                  <ReferenceLine y={plantacao?.phMax} label="Max" stroke="red" />
                  <ReferenceLine y={plantacao?.phMin} label="Min" stroke="red" />
                  <Line type="monotone" dataKey="value" stroke="#8884d8" />
                </LineChart>
              </ResponsiveContainer>
            </div>
          </CardBody>
          <hr></hr>
          <CardBody>
            <Row>
              <Col sm="5">
                <CardTitle><h4>Medição de EC (mS/cm)</h4></CardTitle>
              </Col>
            </Row>
            <div className="chart-wrapper" style={{ height: 400 + 'px', marginTop: 40 + 'px' }}>
              <ResponsiveContainer>
                <LineChart
                  data={sensorEcData}
                  margin={{
                    top: 20, right: 50, left: 20, bottom: 5,
                  }}
                >
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="date" tick={<CustomizedAxisTick />}
                    height={120}
                    interval={0} />
                  <YAxis />
                  <Tooltip formatter={tooltopEc}
                    labelFormatter={tooltipLabelFormatter} />
                  <Legend formatter={legendFormatter} />
                  <ReferenceLine y={plantacao?.ecMax} label="Max" stroke="red" />
                  <ReferenceLine y={plantacao?.ecMin} label="Min" stroke="red" />
                  <Line type="monotone" dataKey="value" stroke="#8884d8" />
                </LineChart>
              </ResponsiveContainer>
            </div>
          </CardBody>
        </> : (<CardBody>Ainda não foram coletados dados.</CardBody>)}
      </Card>
    </Col>
  </Row>
}

export default Plantacao;