package com.noticias.domain.model;

import java.util.UUID;

import org.springframework.data.neo4j.core.schema.GeneratedValue;
import org.springframework.data.neo4j.core.schema.Id;
import org.springframework.data.neo4j.core.schema.Node;

import lombok.Builder;


@Node("User")
public record User(
    @Id 
    @GeneratedValue
    UUID userId,
    String name,
    String email) {

        @Builder(toBuilder = true)
        public User {};
    }
