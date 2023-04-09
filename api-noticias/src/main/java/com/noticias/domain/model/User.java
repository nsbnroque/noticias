package com.noticias.domain.model;

import java.util.List;
import java.util.UUID;

import org.springframework.data.neo4j.core.schema.GeneratedValue;
import org.springframework.data.neo4j.core.schema.Id;
import org.springframework.data.neo4j.core.schema.Node;
import org.springframework.data.neo4j.core.schema.Relationship;

import lombok.Builder;


@Node("User")
public record User(
    @Id 
    @GeneratedValue
    UUID userId,
    String name,
    String email,
    @Relationship(type="LIKES")
    List<Tag> likes,
    @Relationship(type = "ACCESS")
    List<Tag> parameters) {

        @Builder(toBuilder = true)
        public User {};

        public User withEmail(String email) {
            return new User(userId, name, email, likes, parameters);
        }
    }
