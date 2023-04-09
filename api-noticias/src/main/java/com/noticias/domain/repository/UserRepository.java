package com.noticias.domain.repository;

import java.util.UUID;

import org.springframework.data.neo4j.repository.ReactiveNeo4jRepository;
import org.springframework.data.neo4j.repository.config.EnableReactiveNeo4jRepositories;

import com.noticias.domain.model.User;

@EnableReactiveNeo4jRepositories
public interface UserRepository extends ReactiveNeo4jRepository<User,UUID>{
    
}
