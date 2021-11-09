using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClosedXML.Excel;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories;
using Microsoft.Extensions.Options;
using NLog;

namespace LeaguerManagement.Services
{
    public class StatisticsService : BaseService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private IRepository<Leaguer> _leaguerRepository;

        public StatisticsService(Func<IUnitOfWork> unitOfWorkFactory, IOptionsSnapshot<GlobalSettings> settings,
            IMapper mapper, ILogger logger) : base(unitOfWorkFactory, settings)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<byte[]> Export5BTC(int year)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();
            try
            {
                var excelData = await _leaguerRepository.GetData5BTC(year);
                //
                // export to excel
                return Generate5BTC(excelData, year);
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<byte[]> Export4TW(int year)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();
            try
            {
                var excelData = await _leaguerRepository.GetData4TW(year);
                //
                // export to excel
                return Generate4TW(excelData, year);
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        #region Private method

        private byte[] Generate5BTC(Report5BTCModel excelData, int year)
        {
            //dir path của file template
            using var workbook = new XLWorkbook(Path.GetFullPath(Directory.GetCurrentDirectory() + "\\Contents\\Templates\\Mau 5B-TC.xlsx"));
            var worksheet = workbook.GetWorkSheet("Sheet1");
            // declare default variable
            const int totalColumns = 12;
            // starting row
            var currentRow = 7;
            //
            // Start generate content
            // date-year
            worksheet.Cell(2, 6).Value += $"Đà Nẵng, ngày 30 tháng 12 năm {year}";
            worksheet.Cell(3, 1).Value += $"Năm {year}";
            // detail
            var index = 1;
            foreach (var unit in excelData.Units)
            {
                // unit
                currentRow++;
                var rowData = new DropDownModel<string> { Key = unit.IdentifyNumber, Value = unit.Name };
                worksheet.GenerateRowAndStyling(currentRow, totalColumns, true);
                worksheet.PrintCellsValue(rowData, currentRow, totalColumns, printedColumn: 1);
                // leaguers of unit
                foreach (var leaguer in excelData.Leaguers.Where(_ => _.UnitId == unit.Id))
                {
                    currentRow++;
                    worksheet.GenerateRowAndStyling(currentRow, totalColumns);
                    // index
                    worksheet.Cell(currentRow, 1).Value = index;
                    worksheet.Cell(currentRow, 2).Value = leaguer.Name;

                    if (leaguer.RatingId == AppLeaguerRating.Best.ToInt())
                        worksheet.Cell(currentRow, leaguer.RatingId + 2).Value = "X";
                    if (leaguer.RatingId == AppLeaguerRating.Well.ToInt())
                        worksheet.Cell(currentRow, leaguer.RatingId + 3).Value = "X";
                    if (leaguer.RatingId == AppLeaguerRating.Done.ToInt())
                        worksheet.Cell(currentRow, leaguer.RatingId + 4).Value = "X";
                    if (leaguer.RatingId == AppLeaguerRating.NotDone.ToInt())
                        worksheet.Cell(currentRow, leaguer.RatingId + 7).Value = "X";
                    if (leaguer.RatingId == AppLeaguerRating.Temp.ToInt())
                        worksheet.Cell(currentRow, leaguer.RatingId + 11).Value = "X";

                    index++;
                }
            }
            // total
            currentRow++;
            worksheet.GenerateRowAndStyling(currentRow, totalColumns);
            worksheet.Cell(currentRow, 3).FormulaA1 = $"=COUNTIF(C9:C{currentRow},'X')";
            worksheet.Cell(currentRow, 4).FormulaA1 = $"=COUNTIF(D9:D{currentRow},'X')";
            worksheet.Cell(currentRow, 5).FormulaA1 = $"=COUNTIF(E9:E{currentRow},'X')";
            worksheet.Cell(currentRow, 6).FormulaA1 = $"=COUNTIF(F9:F{currentRow},'X')";
            worksheet.Cell(currentRow, 7).FormulaA1 = $"=COUNTIF(G9:G{currentRow},'X')";
            worksheet.Cell(currentRow, 8).FormulaA1 = $"=COUNTIF(H9:H{currentRow},'X')";
            worksheet.Cell(currentRow, 9).FormulaA1 = $"=COUNTIF(I9:I{currentRow},'X')";
            worksheet.Cell(currentRow, 10).FormulaA1 = $"=COUNTIF(J9:J{currentRow},'X')";
            worksheet.Cell(currentRow, 11).FormulaA1 = $"=COUNTIF(K9:K{currentRow},'X')";
            worksheet.Cell(currentRow, 12).FormulaA1 = $"=COUNTIF(L9:L{currentRow},'X')";
            // signature
            worksheet.GenerateMergeCell(currentRow + 2, new MergeCellModel { From = 1, To = 2, Text = "NGƯỜI LẬP BIỂU", IsFontBold = true });
            worksheet.GenerateMergeCell(currentRow + 2, new MergeCellModel { From = 6, To = 11, Text = "T/M ĐẢNG ỦY", IsFontBold = true });
            // wrap text
            worksheet.Columns().Style.Alignment.WrapText = true;
            //add to stream return to controller
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }


        private byte[] Generate4TW(Report4TWModel excelData, int year)
        {
            //dir path của file template
            using var workbook =
                new XLWorkbook(Path.GetFullPath(Directory.GetCurrentDirectory() +
                                                "\\Contents\\Templates\\Mau 4-TW.xlsx"));
            var worksheet = workbook.GetWorkSheet("Sheet1");
            // Start generate content
            // date-year
            worksheet.Cell(3, 1).Value += $"(Tính đến 31/12/{year})";
            // folk
            if (excelData.Folks.Any())
                foreach (var data in excelData.Folks)
                {
                    if (data.Name == "Kinh")
                    {
                        worksheet.Cell(8, 3).Value = data.Total;
                        var percent = data.Total / excelData.Total * 100;
                        worksheet.Cell(8, 5).Value = Math.Round(percent, 2);
                    }
                }
            // female folk
            if (excelData.FemaleFolks.Any())
                foreach (var data in excelData.FemaleFolks)
                {
                    if (data.Name == "Kinh")
                    {
                        worksheet.Cell(8, 4).Value = data.Total;
                    }
                }
            // religion
            if (excelData.Religions.Any())
                foreach (var data in excelData.Religions)
                {
                    switch (data.Name)
                    {
                        case "Không":
                            worksheet.Cell(39, 7).Value = "Không";
                            worksheet.Cell(39, 8).Value = data.Total;
                            worksheet.Cell(39, 10).Value = Math.Round(data.Total / excelData.Total * 100, 2);
                            break;
                        case "Đạo Phật":
                            worksheet.Cell(32, 8).Value = data.Total;
                            worksheet.Cell(32, 10).Value = Math.Round(data.Total / excelData.Total * 100, 2);
                            break;
                    }
                }
            // signature
            worksheet.GenerateMergeCell(41, new MergeCellModel { From = 7, To = 10, Text = $"Đà Nẵng, ngày 30 tháng 12 năm {year}", IsFontBold = false });
            // wrap text
            worksheet.Columns().Style.Alignment.WrapText = true;
            //add to stream return to controller
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        #endregion

    }
}
