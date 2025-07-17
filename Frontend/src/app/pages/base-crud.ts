import { Dialog } from "@angular/cdk/dialog";
import { MatTableDataSource } from "@angular/material/table";

export abstract class BaseCrudComponent<TDto, TService> {
    displayedColumns: string[] = ["name", "options"];
    dataSource: MatTableDataSource<TDto> = new MatTableDataSource<TDto>();

    constructor(protected dialog: Dialog, protected service: TService) {}

    abstract fetch(): Promise<TDto[]>;

    getAll() {
        this.fetch().then(result => {
            this.dataSource.data = result;
        });
    }

    abstract openDialog(data?: TDto): Promise<TDto | null>;

    edit(item: TDto) {
        this.openDialog(item).then(formData => {
            if (!formData) return;
            this.save(formData);
        });
    }

    abstract save(data: TDto): void;

    abstract delete(item: TDto): void;
}
