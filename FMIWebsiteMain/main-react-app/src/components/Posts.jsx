import React from "react";
import { Link } from "react-router-dom";
import { Card, Alert, Typography } from "antd";

export const Posts = ({ posts }) => {
  if (posts) {
    return (
      <div
        style={{
          width: "100%",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        {posts.map((post, index) => {
          return (
            <Card
              key={`${index + post.title}`}
              title={
                <Typography.Title level={4}>{post.title}</Typography.Title>
              }
              extra={<Link to="/post">Читать</Link>}
              className="post-card"
            >
              <span className="post-body-text">{post.body}</span>
            </Card>
          );
        })}
      </div>
    );
  } else {
    return (
      <Alert
        message="Внимание"
        description="Контент доступен только авторизованным пользователям"
        type="warning"
      />
    );
  }
};
