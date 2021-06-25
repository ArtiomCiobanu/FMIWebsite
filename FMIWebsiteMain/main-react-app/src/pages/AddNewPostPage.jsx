import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { Layout, Breadcrumb, Typography, Input, message, Button } from "antd";
import { config } from "../config";

const { Content } = Layout;

export const AddNewPostPage = (props) => {
  const [titleValue, setTitleValue] = useState("");
  const [bodyValue, setBodyValue] = useState("");
  const [titleValidation, setTitleValidation] = useState(false);
  const [bodyValidation, setBodyValidation] = useState(false);

  const history = useHistory();

  const loadError = (mes) => message.error(mes);

  const validationHandle = () => {
    const payload = JSON.stringify({
      title: titleValue,
      content: bodyValue,
    });

    if (titleValue === "") {
      setTitleValidation(true);
    } else {
      setTitleValidation(false);
    }
    if (bodyValue === "") {
      setBodyValidation(true);
    } else {
      setBodyValidation(false);
    }

    fetch(`${config.HOST}/posts/add`, {
      method: "POST",
      // mode: "no-cors",
      headers: {
        Authorization:
          "Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIxMTY1YWJlZS0zZWUwLTQ1YmYtYjljNi01Mjg0MjU0NDY4OTciLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTYyNDY1MzI3MSwiZXhwIjoxNjI1MjU4MDcxLCJpc3MiOiJGTUlXZWJTaXRlTWFpbkFQSSIsImF1ZCI6IlRlc3RBdWRpZW5jZSJ9.1pQ9vO7iak2kld4o4Z8oOHX7Me106aa5aQy91q0sEyU",
      },
      body: payload,
    }).then(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.log(error);
      }
    );

    if (titleValidation && bodyValidation) {
      history.push("/");
    }
  };

  return (
    <Content style={{ padding: "0 50px" }}>
      <Breadcrumb style={{ margin: "16px 0" }}>
        <Breadcrumb.Item>
          <Link to="/">Глввная</Link>
        </Breadcrumb.Item>
        <Breadcrumb.Item>
          <Link to="/">Новости</Link>
        </Breadcrumb.Item>
        <Breadcrumb.Item>Добавить</Breadcrumb.Item>
      </Breadcrumb>
      <div style={{ width: "60%" }}>
        <Typography.Title>Добавить новую публикацию</Typography.Title>

        <Typography.Title level={4}>Заголовок</Typography.Title>
        {titleValidation && (
          <>
            <Typography.Text type="danger">*Обязательное поле</Typography.Text>
            <br />
          </>
        )}
        <Input
          placeholder="Введите заголовок поста"
          value={titleValue}
          onChange={(e) => setTitleValue(e.target.value)}
          size="large"
          className="mb-15"
        />

        <Typography.Title level={4}>Текст</Typography.Title>
        {bodyValidation && (
          <>
            <Typography.Text type="danger">*Обязательное поле</Typography.Text>
            <br />
          </>
        )}
        <Input.TextArea
          placeholder="Введите текст поста"
          value={bodyValue}
          onChange={(e) => setBodyValue(e.target.value)}
          className="mb-15"
          autoSize={false}
          rows={10}
        />

        <Button size="large" type="primary" onClick={validationHandle}>
          Опубликовать
        </Button>
      </div>
    </Content>
  );
};
