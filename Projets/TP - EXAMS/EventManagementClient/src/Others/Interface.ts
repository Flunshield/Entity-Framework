
export interface LocationDto {
    $id: string;
    $values: {
        $id: string;
        id: number;
        name: string;
        address: string;
        city: string | null;
    }[];
}

export interface EventDto {
    $id: string;
    $values: {
        id: number;
        name: string;
        description: string;
        startDate: string;
        endDate: string;
        attendanceStatus: string;
        locationId: number;
        categoryId: number;
    }[];
}


export interface CategoryDto {
    $id: string;
    $values: {
        id: number;
        name: string;
        description: string | null;
    }[];
}
