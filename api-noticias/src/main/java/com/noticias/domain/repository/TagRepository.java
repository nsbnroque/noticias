package com.noticias.domain.repository;

import java.util.UUID;

import org.springframework.data.neo4j.repository.ReactiveNeo4jRepository;
import org.springframework.data.neo4j.repository.config.EnableReactiveNeo4jRepositories;

import com.noticias.domain.model.Tag;

@EnableReactiveNeo4jRepositories
public interface TagRepository extends ReactiveNeo4jRepository<Tag, UUID> {
    
}
