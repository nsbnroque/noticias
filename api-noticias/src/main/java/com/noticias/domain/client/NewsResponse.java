package com.noticias.domain.client;

import java.util.List;

public record NewsResponse(
    String status,
    List<News> sources
) {
    
    
}
